[System.Serializable]
public struct PlayerConquistas{
	[System.Serializable]
	public struct PlayerConquista 
	{
		public int idPlayer;
		public int idConquista;
		public string nome;
		public string descricao;
		public string icone_url;
		public string dificuldade;
		public float progresso;
		public System.DateTime quando;
	}

	public PlayerConquista[] objetos;
}