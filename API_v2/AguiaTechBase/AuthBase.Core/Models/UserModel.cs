using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthBase.Core.Models
{
    public class UserModel : INotification
    {
        public Guid Id { get; set; }
        public Guid UserCredentialId { get; set; }
        public int UserInfosId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
