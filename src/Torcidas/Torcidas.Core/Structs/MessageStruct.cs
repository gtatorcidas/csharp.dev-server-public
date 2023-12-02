namespace Torcidas.Core.Structs
{
    public struct MessageStruct
    {
        public const string IntoInteriorMessageError = "Voce nao pode usar este comando em um interior";
        public const string CannotBringAllNearSpawnMessage = "Voce nao pode trazer todos perto do spawn de sedes.";
        public const string PleaseWaitAdminMessage = "Por favor, aguarde ate algum administrador vir ate voce.";
        public const string RemoveIndicatorMessage = "Voce removeu o indicador.";
        public const string ActiveIndicatorMessage = "Voce ativou o indicador.";
        public const string AutoRemoveGangForbiddenMessage = "Voce nao pode se expulsar da sua propria torcida.";
        public const string RemoveOutsideGangForbiddenMessage = "Voce so pode expulsar jogadores da sua torcida.";
        public const string CannotExecuteOnHigherRoleMessage = "Voce nao pode executar este comando em um jogador com o cargo maior que o seu.";
        public const string CannotKickHigherMinutesMessage = "Voce so pode expulsar um player de uma torcida por entre 1 a 30 minutos.";
        public static string ResultsOfMemberListMessage(int onlineMembers) => $"Resultado: {onlineMembers} membro(s) online.";
        public static string ResultsOfRegisteredMemberListMessage(int onlineMembers) => $"Resultado: {onlineMembers} membro(s) cadastrados.";
        public const string ResultsOfMemberListEmptyMessage = "** Nao foram encontrados membro(s) cadastrados online na torcida.";
        public const string NotFoundRegisteredListMessage = "Nao foram encontrados membro(s) cadastrados online na torcida informada.";
        public const string WithoutAnyPlayerOnGangMessage = "* Ninguem online foi encontrado.";
        public const string WithoutPermissionMessage = "Voce nao tem permissao para usar este comando.";
        public const string CannotLoggedUserMessage = "Este jogador ainda nao esta logado.";
        public const string UserAlreadyRegisteredOnGangMessage = "Esse jogador ja esta cadastrado nessa torcida.";
        public const string CannotExecuteCommandOutsideGangMessage = "Voce so pode executar este comando em jogadores da sua torcida.";
        public const string CannotRegisterUserHigherRankMessage = "Voce nao pode cadastrar um jogador com cargo maior que o seu.";
        public const string InvalidGangOnListMessage = "Torcida invalida, use '/torcidas' para saber um ID valido.";
        public const string GangWithoutUnionMessage = "A sua torcida nao possui nenhum aliado no momento.";
        public const string RemovePlayerFromGangSyntaxMessage = "/expulsartorcida [playerId] [tempo] [motivo]";
    }
}
