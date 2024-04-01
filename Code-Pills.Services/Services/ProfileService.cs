using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.DataAccess.Models;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class ProfileService: IProfileService
    {
        private readonly IProfileRepo _profileRepo;
        private readonly IMapper _mapper;
        private readonly IJwtToken _tokenService;

        public ProfileService(IProfileRepo profileRepo, IMapper mapper, IJwtToken tokenService)
        {
            _profileRepo = profileRepo;
            _mapper = mapper;
            _tokenService = tokenService;
            _tokenService = tokenService;
        }
        public async Task<string> SaveProfile(ProfileDTO profile)
        {
            PersonalInfo newProfile = _mapper.Map<PersonalInfo>(profile);
            return await _profileRepo.SaveProfile(newProfile);
        }
        public async Task<ProfileDTO?> GetProfile()
        {
            string userId = _tokenService.GetUserId();
            PersonalInfo personalInfo= await _profileRepo.GetProfile(userId);
            ProfileDTO userInfo = _mapper.Map < ProfileDTO >(personalInfo);
            return userInfo;
        }
        public async Task<string> SavePerformance(PerformanceDTO performance)
        {
            PerformanceMapping userPerformance = _mapper.Map<PerformanceMapping>(performance);
            return await _profileRepo.SavePerformance(userPerformance);
        }
        public async Task<string> EditPerformance(PerformanceDTO performance)
        {
            PerformanceMapping userPerformance = _mapper.Map<PerformanceMapping>(performance);
            return await _profileRepo.EditPerformance(userPerformance);
        }

        public async Task<bool> IsUserNameTaken(string userName)
        {
            return await _profileRepo.IsUserNameUnique(userName);
        }
        public async Task<IEnumerable<GlobalRank>> GetGlobalRanks()
        {
            return await _profileRepo.GetGlobalRanks();
        }
        public async Task<PerformanceDTO> GetProfileStats()
        {
            string userId = _tokenService.GetUserId();
            PerformanceDTO profile = _mapper.Map <PerformanceDTO>(await _profileRepo.GetProfileStats(userId));
            return profile;
        }

        public async Task<UserReport> GetUserReport()
        {
            string userId = _tokenService.GetUserId();
            return await _profileRepo.GetUserReport(userId);            
        }

        public async Task<double> CalculateRating(double accuracy, int attempts, int solvedQuestions, int incompleteQuestions, int creditsCount, int contestPerformance)
        {
            accuracy = 38;
            attempts = 100;
            solvedQuestions = 38;
            incompleteQuestions = 62;
            creditsCount = 600;
            contestPerformance = 0;
            double accuracyWeight = 0.4;
            double attemptsWeight = 0.0;
            double solvedQuestionsWeight = 0.0;
            double incompleteQuestionsPenalty = 0.1; // Penalty for incomplete questions
            double creditsCountWeight = 0.15;
            double contestPerformanceWeight = 0.3;

            // Normalize metrics (assuming all metrics are already on a relative scale)
            double normalizedAccuracy = accuracy; // No need for normalization
            double normalizedAttempts = Normalize(attempts); // Normalize attempts
            double normalizedSolvedQuestions = Normalize(solvedQuestions); // Normalize solved questions
            double normalizedIncompleteQuestions = Normalize(incompleteQuestions); // Normalize incomplete questions
            double normalizedCreditsCount = Normalize(creditsCount); // Normalize credits count
            double normalizedContestPerformance = Normalize(contestPerformance); // Normalize contest performance

            // Calculate weighted sum
            double weightedSum = (normalizedAccuracy * accuracyWeight) +
                                 (normalizedAttempts * attemptsWeight) +
                                 (normalizedSolvedQuestions * solvedQuestionsWeight) +
                                 ((1 - normalizedIncompleteQuestions) * incompleteQuestionsPenalty) +
                                 (normalizedCreditsCount * creditsCountWeight) +
                                 (normalizedContestPerformance * contestPerformanceWeight);

            // Map weighted sum to rating scale (1 to 5)
            double minScore = 0; // Minimum possible score
            double maxScore = 1; // Maximum possible score
            double minRating = 1; // Minimum rating
            double maxRating = 5; // Maximum rating

            double rating = Math.Round(((weightedSum - minScore) / (maxScore - minScore)) * (maxRating - minRating)) + minRating;

            // Ensure rating is within range
            return Math.Max(minRating, Math.Min(maxRating, rating));
        }

        // Helper method to normalize a value (dummy implementation for demonstration)
        private double Normalize(int value)
        {
            // Example: Normalizing value between 0 and 1 based on its rank
            return value / (double.MaxValue - double.MinValue);
        }

    }
}
