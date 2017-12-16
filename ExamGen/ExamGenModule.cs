using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;

namespace ExamGen
{
    public sealed class ExamGenModule : NancyModule
    {
        public ExamGenModule()
        {
            Get("/",
                args => string.Join(Environment.NewLine,
                    GenerateRandomList(20, "questions.txt").Zip(Enumerable.Range(1, 20),
                        (question, index) => index + ". " + question)));
        }

        public List<string> GenerateRandomList(int number, string filePath) => File.ReadAllLines(filePath).ToList()
            .Where(x => !string.IsNullOrEmpty(x)).OrderBy(x => Guid.NewGuid()).Take(number).ToList();
    }
}
