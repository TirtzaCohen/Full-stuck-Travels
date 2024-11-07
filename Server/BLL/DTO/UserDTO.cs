using System;
using System.Collections.Generic;

namespace BLL.DTO;

public class UserDTO
{
    public int UserCode { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public string Phone { get; set; }

    public string? Email { get; set; }

    public string? LoginPassword { get; set; }

    public bool FirstAidCertificate { get; set; }

}
