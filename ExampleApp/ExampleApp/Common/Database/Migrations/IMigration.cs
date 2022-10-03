using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Common.Database.Migrations
{
    public interface IMigration
    {
        Task Run();
    }
}
