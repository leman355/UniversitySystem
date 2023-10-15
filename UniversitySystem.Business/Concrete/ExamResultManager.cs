using AutoMapper;
using UniversitySystem.Business.DTO.ExamResultDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Business.Abstract;

namespace UniversitySystem.Business.Concrete
{
    public class ExamResultManager : IExamResultService
    {
        private readonly IExamResultRepository _examResultRepository;
        private readonly IMapper _mapper;

        public ExamResultManager(IExamResultRepository examResultRepository, IMapper mapper)
        {
            _examResultRepository = examResultRepository;
            _mapper = mapper;
        }

        public async Task<List<ExamResultToListDto>> GetAllExamResults()
        {
            var examResults = await _examResultRepository.GetAllExamResults();
            return _mapper.Map<List<ExamResultToListDto>>(examResults);
        }

        public async Task<ExamResultToListDto> GetExamResultById(int examResultId)
        {
            var examResults = await _examResultRepository.GetExamResultById(examResultId);
            return _mapper.Map<ExamResultToListDto>(examResults);
        }

        public async Task<List<ShortExamResultToListDto>> GetExamResultsByStudentId(int studentId)
        {
            var examResults = await _examResultRepository.GetExamResultsByStudentId(studentId);
            return _mapper.Map<List<ShortExamResultToListDto>>(examResults);
        }
        public async Task<List<ShortExamResultToListDto>> GetExamResultsByTeacherId(int teacherId)
        {
            var examResults = await _examResultRepository.GetExamResultsByTeacherId(teacherId);
            return _mapper.Map<List<ShortExamResultToListDto>>(examResults);
        }

        public async Task<List<ShortExamResultToListDto>> GetExamResultsByExamId(int examId)
        {
            var examResults = await _examResultRepository.GetExamResultsByExamId(examId);
            return _mapper.Map<List<ShortExamResultToListDto>>(examResults);
        }

        public async Task<ExamResultToAddDto> CreateExamResult(ExamResultToAddDto dto)
        {
            var examResult = _mapper.Map<ExamResult>(dto);
            var createdExamResult = await _examResultRepository.CreateExamResult(examResult);
            return _mapper.Map<ExamResultToAddDto>(createdExamResult);
        }

        public async Task<ExamResultToUpdateDto> UpdateExamResult(int examResultId, ExamResultToUpdateDto dto)
        {
            var existingExamResult = await _examResultRepository.GetExamResultById(examResultId);

            if (existingExamResult == null)
            {
                return null;
            }

            _mapper.Map(dto, existingExamResult);

            var updatedExamResult = await _examResultRepository.UpdateExamResult(existingExamResult);
            return _mapper.Map<ExamResultToUpdateDto>(updatedExamResult);
        }

        public async Task DeleteExamResultById(int examResultId)
        {
            await _examResultRepository.DeleteExamResultById(examResultId);
        }
    }
}
