using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.ICommon
{
    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
