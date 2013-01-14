using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Redmine
{
  public class CurrentUserResult
  {
    public CurrentUser user { get; set; }
  }

  public class CurrentUser
  {
    public int id { get; set; }
  }
}
