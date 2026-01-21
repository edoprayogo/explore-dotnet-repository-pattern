using System;
using System.Collections.Generic;
using System.Text;

namespace explore_pattern.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }

}
