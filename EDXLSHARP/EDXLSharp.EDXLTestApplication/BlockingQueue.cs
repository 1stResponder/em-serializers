// <copyright file="BlockingQueue.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
/*
 *   Module Operations
 *   -----------------
 *   This module preforms communication between two threads using a 
 *   blocking queue.  If the queue is empty when the reader attempts to deQ
 *   an item then the reader will block until the writing thread enQs an item.
 *   Thus waiting is efficient.
 * 
 *   NOTE!
 *   Double-checked locking, used in DeQueue() devised by Douglas Schmidt, as part
 *   of the ACE communication package developed at Washington Univ, St. Louis,
 *   Missouri.
 * 
 */

using System.Collections;
using System.Threading;

namespace ThreadSafeBlockingQ
{
  /// <summary>
  /// Thread Safe Blocking Queue class definition
  /// </summary>
  /// <typeparam name="T">Lock flag parameter</typeparam>
  public class BlockingQueue<T>
  {
    /// <summary>
    /// Blocking queue object
    /// </summary>
    private Queue blockingQ;

    /// <summary>
    /// Manual Reset Event 
    /// </summary>
    private ManualResetEvent ev;

    /// <summary>
    /// Initializes a new instance of the BlockingQueue class
    /// Constructor - Creates A New Thread-Safe Blocking Queue
    /// </summary>
    public BlockingQueue()
    {
      Queue mQ = new Queue();
      this.blockingQ = mQ;
      this.ev = new ManualResetEvent(false);
    }

    /// <summary>
    /// Enqueues a Message of Type T in The Queue - Thread Safe Lock
    /// </summary>
    /// <param name="message">Input Message of Template Type T</param>
    public void EnQueue(T message)
    {
      lock (this.blockingQ)
      {
        this.blockingQ.Enqueue(message);
        this.ev.Set();
      }
    }

    /// <summary>
    /// Pulls a Message of Type T from the Top of the Queue - Thread Safe Lock 
    /// </summary>
    /// <returns>Message of Template Type T</returns>
    public T DeQueue()
    {
      T outputMessage = default(T);
      while (true)
      {
        if (this.Size() == 0)
        {
          this.ev.Reset();
          this.ev.WaitOne();
        }

        lock (this.blockingQ)
        {
          // The Second Count Check is Needed if a single item is in the queue and the thread moved to deQ
          // but finishes the time allocation before deQ'ing another thread may get through and will lock the blockingQ
          if (this.blockingQ.Count != 0)
          {
            outputMessage = (T)this.blockingQ.Dequeue();
            break;
          }
        }
      }

      return outputMessage;
    }

    /// <summary>
    /// Number of Elements Currently in the Queue
    /// </summary>
    /// <returns>Number of Elements in the Queue</returns>
    public int Size()
    {
      int count;
      lock (this.blockingQ)
      {
        count = this.blockingQ.Count;
      }

      return count;
    }

    /// <summary>
    /// Purges All Elements From The Queue
    /// </summary>
    public void Clear()
    {
      lock (this.blockingQ)
      {
        this.blockingQ.Clear();
      }
    }
  }
}
