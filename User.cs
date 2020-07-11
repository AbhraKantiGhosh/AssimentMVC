//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int userid { get; set; }
        [Required(ErrorMessage ="Pls Enter Username")]
        public string username { get; set; }
        [Required()]
        [StringLength(12,ErrorMessage ="",MinimumLength =8)]
        public string password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
