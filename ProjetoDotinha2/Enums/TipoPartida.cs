using System.ComponentModel;

namespace ProjetoDotinha2.Enums
{
    public enum TipoPartida
    {
        [Description("Desconhecido")]
        Desconhecido = 0,

        [Description("Escolha Livre")]
        Escolha_Livre = 1,

        [Description("Modo de Capitão")]
        Modo_de_capitao = 2,

        [Description("Escolha Aleatória")]
        Escolha_Aleatoria = 3,

        [Description("Escolha Única")]
        Escolha_unica = 4,

        [Description("Escolha Aleatória")]
        Escolha_aleatoria = 5,

        [Description("Intro")]
        Intro = 6,

        [Description("Diritide")]
        Diritide = 7,

        [Description("Modo de Capitão Reverso")]
        Modo_de_capitao_reverso = 8,

        [Description("The Greeviling")]
        The_Greeviling = 9,

        [Description("Tutorial")]
        Tutorial = 10,

        [Description("Apenas Mid")]
        Apenas_mid = 11,

        [Description("Menos Jogados")]
        Menos_jogados = 12,

        [Description("Modo para Iniciantes")]
        Modo_para_iniciantes = 13,

        [Description("Compendium MatchMaking")]
        Compendium_MatchMaking = 14,

        [Description("Customizada")]
        Customizada = 15,

        [Description("Seleção de Capitães")]
        Selecao_de_capitaes = 16,

        [Description("Seleção Balanceada")]
        Selecao_balanceada = 17,

        [Description("Seleção de Habilidades")]
        Selecao_de_habilidades = 18,

        [Description("Evento")]
        Evento = 19,

        [Description("Mata-Mata Todos Aleatórios")]
        Mata_Mata_Todos_Aleatorios = 20,

        [Description("Mid 1 vs 1")]
        Mid_1_vs_1 = 21,

        [Description("Rankeada Escolha Livre")]
        Rankeada_Escolha_Livre = 22,

        [Description("Modo Turbo")]
        Modo_turbo = 23
    }
}
