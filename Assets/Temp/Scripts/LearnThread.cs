using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LearnThread : MonoBehaviour
{
         void Start()
        {
        /* Tạo một Thread t với anonymous function và gọi hàm DemoThread bên trong
         * Thread chỉ bắt đầu chạy khi gọi hàm Start
         * Bạn có thể thực hiện một hàm hay nhiều dòng code ở bên trong anonymous function này
         */
        //Thread t = new Thread(() => {   
        //    DemoThread("Thread 1");
        //});
        //t.Start();

        //Thread t2 = new Thread(() => {
        //    DemoThread("Thread 2");
        //});
        //t2.Start();

        //Thread t3 = new Thread(() => {
        //    DemoThread("Thread 3");
        //});
        //t3.Start();

        float _Time = System.DateTime.Now.Millisecond;

        for (int i = 0; i < 5; i++)
        {
            //DemoThread("Thread" + i);

            int Index = i;

            ThreadStart _Start = new ThreadStart(() =>
            {
                DemoThread("Thread " + Index);
            });

            _Start += () => { Debug.LogError(System.DateTime.Now.Millisecond - _Time); };

            Thread t = new Thread(_Start);
            t.Start();
        }

        Debug.LogError(System.DateTime.Now.Millisecond - _Time);
    }

    public static int COUNT = 0;
    static void DemoThread(string threadIndex)
        {
            for (int i = 0; i < 100; i++)
            {
            COUNT++;
                Debug.Log(threadIndex + " - " + COUNT);
            }
        }
}
