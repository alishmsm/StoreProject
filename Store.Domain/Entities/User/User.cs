using Microsoft.AspNetCore.Identity;
using Store.Domain.Attributes;

namespace Store.Domain.Entities.User;

[Auditable]
public class User : IdentityUser
{
    public string FullName { get; set; }
}