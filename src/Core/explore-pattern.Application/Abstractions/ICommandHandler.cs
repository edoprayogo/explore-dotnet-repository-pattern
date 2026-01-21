using System;
using System.Collections.Generic;
using System.Text;

namespace explore_pattern.Application.Abstractions
{
    public interface ICommandHandler<TCommand, TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }

}
