using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.AnswerDtos;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerManager(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<AnswerToListDto>> GetAllAnswers()
        {
            var answers = await _answerRepository.GetAllAnswers();
            return _mapper.Map<List<AnswerToListDto>>(answers);
        }

        public async Task<AnswerToListDto> GetAnswerById(int answerId)
        {
            var answer = await _answerRepository.GetAnswerById(answerId);
            return _mapper.Map<AnswerToListDto>(answer);
        }

        public async Task<List<AnswerToListDto>> GetAnswersByQuestion(int questionId)
        {
            var answers = await _answerRepository.GetAnswersByQuestion(questionId);
            return _mapper.Map<List<AnswerToListDto>>(answers);
        }

        public async Task<AnswerToAddDto> CreateAnswer(AnswerToAddDto dto)
        {
            var answer = _mapper.Map<Answer>(dto);
            var createdAnswer = await _answerRepository.CreateAnswer(answer);
            return _mapper.Map<AnswerToAddDto>(createdAnswer);
        }

        public async Task<AnswerToUpdateDto> UpdateAnswer(int answerId, AnswerToUpdateDto dto)
        {
            var existingAnswer = await _answerRepository.GetAnswerById(answerId);

            if (existingAnswer == null)
            {
                return null;
            }

            _mapper.Map(dto, existingAnswer);

            var updatedAnswer = await _answerRepository.UpdateAnswer(existingAnswer);
            return _mapper.Map<AnswerToUpdateDto>(updatedAnswer);
        }

        public async Task DeleteAnswerById(int answerId)
        {
            await _answerRepository.DeleteAnswerById(answerId);
        }
    }
}
