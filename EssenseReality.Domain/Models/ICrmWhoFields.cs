using System;

namespace EssenseReality.Domain.Models
{
    public interface ICrmWhoFields
    {
        DateTime Inserted { get; set; }
        DateTime Modified { get; set; }
    }
}
