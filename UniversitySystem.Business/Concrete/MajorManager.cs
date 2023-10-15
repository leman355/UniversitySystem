using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.MajorDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;

namespace UniversitySystem.Business.Concrete
{
    public class MajorManager : IMajorService
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IMapper _mapper;

        public MajorManager(IMajorRepository majorRepository, IMapper mapper)
        {
            _majorRepository = majorRepository;
            _mapper = mapper;
        }

        public async Task<List<MajorToListDto>> GetAllMajors()
        {
            var majors = await _majorRepository.GetAllMajors();
            return _mapper.Map<List<MajorToListDto>>(majors);
        }

        public async Task<MajorToListDto> GetMajorById(int majorId)
        {
            var major = await _majorRepository.GetMajorById(majorId);
            return _mapper.Map<MajorToListDto>(major);
        }

        public async Task<MajorToAddDto> CreateMajor(MajorToAddDto dto)
        {
            var major = _mapper.Map<Major>(dto);
            var createdMajor = await _majorRepository.CreateMajor(major);
            return _mapper.Map<MajorToAddDto>(createdMajor);
        }

        public async Task<MajorToUpdateDto> UpdateMajor(int majorId, MajorToUpdateDto dto)
        {
            var existingMajor = await _majorRepository.GetMajorById(majorId);

            if (existingMajor == null)
            {
                return null;
            }

            _mapper.Map(dto, existingMajor);

            var updatedMajor = await _majorRepository.UpdateMajor(existingMajor);
            return _mapper.Map<MajorToUpdateDto>(updatedMajor);
        }

        public async Task DeleteMajorById(int majorId)
        {
            await _majorRepository.DeleteMajorById(majorId);
        }
    }
}
