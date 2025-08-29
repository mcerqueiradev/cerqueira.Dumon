using cerqueira.Dumon.Domain.Core.Abstractions;
using System.Linq.Expressions;

namespace cerqueira.Dumon.Domain.Core.Common;

public class OrSpecification<T> : BaseSpecification<T>
{
    public OrSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var combined = Expression.OrElse(
            Expression.Invoke(left.Criteria, parameter),
            Expression.Invoke(right.Criteria, parameter)
        );
        Criteria = Expression.Lambda<Func<T, bool>>(combined, parameter);
    }
}
