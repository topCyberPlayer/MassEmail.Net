namespace MassEmail.Net.Queues
{
    public interface IQueue
    {
        /// <summary>
        /// Метод для отправки сообщений в очередь
        /// </summary>
        /// <param name="listEmail"></param>
        void SendToQueue(ICollection<string> listEmail);
        
        /// <summary>
        /// Метод для получения сообщений из очереди
        /// </summary>
        /// <returns></returns>
        string GetFromQueue();

        /// <summary>
        /// Метод для ручного удаления сообщений (эл. почты) из очереди после подтверждения отправки
        /// </summary>
        /// <param name="email"></param>
        void RemoveFromQueue(string email);
    }
}
