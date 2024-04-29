using DiffPlex.DiffBuilder.Model;

namespace DBGuard.Shared.DTO.Text;

public sealed class DiffLineResult
{
    public ChangeType Type { get; set; }

    public int? Position { get; set; }

    public string Text { get; set; } = string.Empty;

    public List<DiffPiece> SubPieces { get; set; } = new();
}
