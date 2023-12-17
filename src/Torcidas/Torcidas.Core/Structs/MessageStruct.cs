namespace Torcidas.Core.Structs
{
    public struct MessageStruct
    {
        public const string UserNotFoundMessage = "O player informado nao foi encontrado.";
        public const string ForbiddenToSendMessageToYourselfMessage = "Voce nao pode enviar uma mensagem privada para si mesmo.";
        public const string YouMovedMessage = "Voce se moveu, o suicidio foi cancelado.";
        public const string UserNotFoundWithParameterMessage = "* Nao foi encontrado nenhum player com o termo informado.";
        public const string SearchParameterMaxSizeMessage = "O termo de busca so pode ter no maximo 24 caracteres.";
    }
}
