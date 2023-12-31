﻿using EnterComputers.DataAcces.Utils;

namespace EnterComputers.DataAcces.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams  @params);
}
