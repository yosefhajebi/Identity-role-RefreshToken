// using TestIdentity.Application.DTOs;
// using TestIdentity.Application.Interfaces;
// using TestIdentity.Domain.Interfaces;
// using TestIdentity.Domain.ValueObjects;
// using TestIdentity.Domain.Entities;
// using TestIdentity.Application.Exceptions;
// using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Logging;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;
using AutoMapper;


namespace TestIdentity.Application.Services;

public abstract class BaseService<TEntity,TCreate, TUpdate, TDto>:IService<TEntity,TCreate, TUpdate, TDto>
    where TEntity : class
    where TCreate : class
    where TUpdate : class
    where TDto : class
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly ILogger<BaseService<TEntity,TCreate, TUpdate, TDto>> _logger;
    protected readonly IRepository<TEntity> _repository;
     protected readonly IMapper _mapper;
    protected BaseService(IUnitOfWork unitOfWork, ILogger<BaseService<TEntity, TCreate, TUpdate, TDto>> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _repository = _unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }

    public virtual async Task<TCreate> CreateAsync(TCreate dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TCreate>(entity);        
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
       var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"{typeof(TEntity).Name} با شناسه {id} یافت نشد.");

        return _mapper.Map<TDto>(entity);
    }

    public Task<bool> UpdateAsync(TUpdate dto)
    {
        throw new NotImplementedException();
    }
}

