using DBGuard.Shared.DTO.Text;

namespace DBGuard.SqlService.BLL.Interfaces;

public interface ITextService
{
    InLineDiffResultDto GetInlineDiffs(TextPairRequestDto textPairDto);
    SideBySideDiffResultDto GetSideBySideDiffs(TextPairRequestDto textPairDto);
}