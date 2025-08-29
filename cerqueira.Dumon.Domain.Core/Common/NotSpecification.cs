using cerqueira.Dumon.Domain.Core.Abstractions;
using System.Linq.Expressions;

namespace cerqueira.Dumon.Domain.Core.Common;

public class NotSpecification<T> : BaseSpecification<T>
{
    public NotSpecification(ISpecification<T> specification)
    {
        Criteria = Expression.Lambda<Func<T, bool>>(
            Expression.Not(specification.Criteria.Body),
            specification.Criteria.Parameters
        );
    }
}
