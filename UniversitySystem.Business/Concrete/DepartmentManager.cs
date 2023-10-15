using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.DepartmentDtos;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentToListDto>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            return _mapper.Map<List<DepartmentToListDto>>(departments);
        }

        public async Task<DepartmentToListDto> GetDepartmentById(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentById(departmentId);
            return _mapper.Map<DepartmentToListDto>(department);
        }

        public async Task<DepartmentToAddDto> CreateDepartment(DepartmentToAddDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            var createdDepartment = await _departmentRepository.CreateDepartment(department);
            return _mapper.Map<DepartmentToAddDto>(createdDepartment);
        }

        public async Task<DepartmentToUpdateDto> UpdateDepartment(int departmentId, DepartmentToUpdateDto dto)
        {
            var existingDepartment = await _departmentRepository.GetDepartmentById(departmentId);

            if (existingDepartment == null)
            {
                return null;
            }

            _mapper.Map(dto, existingDepartment);

            var updatedDepartment = await _departmentRepository.UpdateDepartment(existingDepartment);
            return _mapper.Map<DepartmentToUpdateDto>(updatedDepartment);
        }

        public async Task DeleteDepartmentById(int departmentId)
        {
            await _departmentRepository.DeleteDepartmentById(departmentId);
        }
    }
}