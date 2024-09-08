using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq;

namespace Repositories
{
    public class LinkLineRepository : ILinkLineRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public LinkLineRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Add(LinkLine linkLine)
        {
            _repositoryContext.LinkLines.Add(linkLine);
        }
    }
}