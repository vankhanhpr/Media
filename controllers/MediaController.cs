using System;
using System.Collections.Generic;
using System.Linq;
using DashBoardService.server.bcs;
using MediaService.model;
using Microsoft.AspNetCore.Mvc;

namespace DashBoardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IBsc m_bsc;

        public MediaController(IBsc _bsc)
        {
            m_bsc = _bsc;

        }
        [HttpPost("getMedia")]
        public dynamic getMedia([FromBody] Request rq )
        {
            try
            {
                return m_bsc.getMedia(rq);
            }
            catch(Exception e)
            {
                return e;
            }
           
        }

    }
}
