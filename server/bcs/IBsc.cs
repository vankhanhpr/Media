
using MediaService.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoardService.server.bcs
{
    public interface IBsc
    {
        dynamic getMedia(Request request);
    }
}
