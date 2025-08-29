using cerqueira.Dumon.Domain.Core.Abstractions;
using System.Linq.Expressions;

namespace cerqueira.Dumon.Domain.Core.Common;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; protected set; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();
    public Expression<Func<T, object>> OrderBy { get; protected set; }
    public Expression<Func<T, object>> OrderByDescending { get; protected set; }
    public Expression<Func<T, object>> ThenBy { get; protected set; }
    public Expression<Func<T, object>> ThenByDescending { get; protected set; }
    public int Take { get; protected set; }
    public int Skip { get; protected set; }
    public bool IsPagingEnabled { get; protected set; }
    public bool IsTrackingEnabled { get; protected set; } = true;

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }

    protected virtual void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }

    protected virtual void ApplyThenBy(Expression<Func<T, object>> thenByExpression)
    {
        ThenBy = thenByExpression;
    }

    protected virtual void ApplyThenByDescending(Expression<Func<T, object>> thenByDescendingExpression)
    {
        ThenByDescending = thenByDescendingExpression;
    }

    protected virtual void DisableTracking()
    {
        IsTrackingEnabled = false;
    }

    public virtual ISpecification<T> And(ISpecification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }

    public virtual ISpecification<T> Or(ISpecification<T> specification)
    {
        return new OrSpecification<T>(this, specification);
    }

    public virtual ISpecification<T> Not()
    {
        return new NotSpecification<T>(this);
    }
}