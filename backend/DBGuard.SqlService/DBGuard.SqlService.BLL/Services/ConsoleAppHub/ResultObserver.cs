﻿using System.Collections.Concurrent;
using DBGuard.ConsoleApp.Models;
using DBGuard.Shared.Exceptions;
using DBGuard.SqlService.BLL.Interfaces.ConsoleAppHub;

namespace DBGuard.SqlService.BLL.Services.ConsoleAppHub;

public sealed class ResultObserver : IResultObserver
{
    private readonly ConcurrentDictionary<Guid, TaskCompletionSource<QueryResultTable>> _pendingRequests = new();
    private const int SecondsToTimeout = 45;

    public TaskCompletionSource<QueryResultTable> Register(Guid queryId)
    {
        var tcs = new TaskCompletionSource<QueryResultTable>();
        if (!_pendingRequests.TryAdd(queryId, tcs))
        {
            throw new QueryAlreadyExistException(queryId);
        }

        _ = RemoveIfNotSetAsync(queryId);

        return tcs;
    }

    public void SetResult(Guid queryId, QueryResultTable queryResultTableDto)
    {
        if (_pendingRequests.TryRemove(queryId, out var tcs))
        {
            tcs.TrySetResult(queryResultTableDto);
        }
        else
        {
            throw new QueryExpiredException(queryId);
        }
    }

    private async Task RemoveIfNotSetAsync(Guid queryId)
    {
        await Task.Delay(TimeSpan.FromSeconds(SecondsToTimeout));
        if (_pendingRequests.TryRemove(queryId, out var removedTcs))
        {
            removedTcs.TrySetCanceled();
        }
        else
        {
            throw new QueryExpiredException(queryId);
        }
    }
}