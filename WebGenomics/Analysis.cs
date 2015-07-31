using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebGenomics
{
    [DataContract]
    public class Analysis
    {
        [DataMember]
        private readonly string[] StrongestGenes;
        [DataMember]
        private readonly Dictionary<string, double> FullGenome;
        [DataMember]
        private readonly string[] Topics;
        [DataMember]
        private readonly string url;
        [DataMember]
        private readonly string LanguageCode;
        [DataMember]
        private readonly string LanguageFullName;
        [DataMember]
        private readonly bool Pornography;
        [DataMember]
        private readonly bool OffensiveLanguage;
        public Analysis(string url, string[] genes, string[] topics, Dictionary<string, double> genome, string languageCode, string languageFullName, bool porn, bool offensiveLan)
        {
            this.StrongestGenes = genes;
            this.Topics = topics;
            this.FullGenome = genome;
            this.url = url;
            this.LanguageCode = languageCode;
            this.LanguageFullName = languageFullName;
            this.Pornography = porn;
            this.OffensiveLanguage = offensiveLan;
        }
    }
}