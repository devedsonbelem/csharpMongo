using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMongoProject.Dto
{
    public class PaginationRequest
    {
        #region Propriedades

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        #endregion
    }
}
