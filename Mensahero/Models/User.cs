using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mensahero.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passowrd { get; set; }
    }
}
