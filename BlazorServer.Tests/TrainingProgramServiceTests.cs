using Autofac.Extras.Moq;
using BlazorServer.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlazorServer.Tests
{
    [TestFixture]
    public class TrainingProgramServiceTests
    {

        private readonly TrainingProgram sampleTP = new TrainingProgram
        {
            TrainingProgramName = "",
            Trainings = new List<Training>
                {
                    new Training
                    {
                        TrainingName="",
                        Exercises=new List<Exercise>
                        {
                            new Exercise
                            {
                                ExerciseName="",
                                NumberOfSets=1,
                                NumberOfRepeats=1,
                                Weight="0 kg"
                            }
                        }
                    }
                }
        };

        [Test]
        public void CreateTPValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<TrainingProgramContext>()
                    .Setup(x => x.Add(sampleTP));

                var real = mock.Create<TrainingProgramService>();
                real.CreateTrainingProgram(sampleTP);
                mock.Mock<TrainingProgramContext>()
                    .Verify(m => m.Add(sampleTP), Times.Exactly(1));
            }
        }
        
        [Test]
        public void DeleteTPValid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<TrainingProgramContext>()
                    .Setup(x => x.Remove(sampleTP));

                var real = mock.Create<TrainingProgramService>();
                real.DeleteProgram(sampleTP);
                mock.Mock<TrainingProgramContext>()
                    .Verify(m => m.Remove(sampleTP), Times.Exactly(1));
            }
        }

    }
}


//    using (var mock = AutoMock.GetLoose())
//    {
//        mock.Mock<TrainingProgramContext>()
//            .Setup(x=>x.)
//            .Returns(GetSampleTPs());

//        var real = mock.Create<TrainingProgramService>();

//        var expected = GetSampleTPs();
//        List<TrainingProgram> actual = await real.GetTrainingProgramsAsync();

//        Assert.True(actual != null);
//        Assert.AreEqual(expected.Count, actual.Count);

//        if (expected.Count == actual.Count)
//        {
//            for (int i = 0; i < expected.Count; ++i)
//            {
//                var expTrainings = expected[i].Trainings;
//                var actTrainings = actual[i].Trainings;
//                Assert.AreEqual(expected[i].Trainings.Count, actual[i].Trainings.Count);

//                if (expTrainings.Count == actTrainings.Count)
//                {
//                    for (int j = 0; j < expTrainings.Count; ++j)
//                    {
//                        Assert.AreEqual(expTrainings[j].Exercises.Count, actTrainings[j].Exercises.Count);
//                    }
//                }
//            }
//        }
//    }