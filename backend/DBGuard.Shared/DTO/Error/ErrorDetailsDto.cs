using DBGuard.Shared.Enums;

namespace DBGuard.Shared.DTO.Error;

public record ErrorDetailsDto(string Message, ErrorType ErrorType);
