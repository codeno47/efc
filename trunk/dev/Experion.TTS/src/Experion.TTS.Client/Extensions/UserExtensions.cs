using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.TTS.Client.Extensions
{
    using Experion.TTS.Client.Model;
    using Experion.TTS.Service.Model;

    public static class UserExtensions
    {
        public static ProjectMemberModel ToMemberModel(this USER_DEFN user)
        {
            if (user == null)
            {
                return null;
            }

            return new ProjectMemberModel
                                    {
                                        Name = user.UserName,
                                        UserId = user.Id,

                                    };

        }

        /// <summary>
        /// To the member model.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static ProjectMemberModel ToMemberModel(this ProjectMember user)
        {
            if (user == null)
            {
                return null;
            }

            return new ProjectMemberModel
            {
                Name = user.USER_DEFN.UserName,
                UserId = user.Id,

            };

        }

        /// <summary>
        /// To the member models.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public static IEnumerable<ProjectMemberModel> ToMemberModels(this IEnumerable<USER_DEFN> users)
        {
            if (users == null)
            {
                return null;
            }
            return users.Select(x => x.ToMemberModel());
        }
    }
}
