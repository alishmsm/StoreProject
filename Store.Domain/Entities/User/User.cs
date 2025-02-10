using Store.Domain.Attributes;

namespace Store.Domain.Entities.User;

[Auditable]
public class User
{
    public long Id { get; set; }
    public string FullName { get; set; }
}