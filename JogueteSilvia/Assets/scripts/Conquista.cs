[System.Serializable]
public struct Conquistas
{
	[System.Serializable]
	public struct Conquista
	{
		public int idConquista;
		public string nome;
		public string descricao;
		public string icone_url;
		public string dificuldade;
	}

	public Conquista[] objetos;
}