namespace SoAt.Application.Sc;

/// ค้นหาทะเบียนสมาชิก — service กลาง reuse ได้ทุกเมนู (popup PopFindMember)
public interface IMemberFindService
{
    Task<List<MemberFindDto>> FindAsync(MemberFindFilter filter);
}
