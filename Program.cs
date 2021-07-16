using System;
using System.Diagnostics;

namespace commandtest
{
    class Program
    {
        static int Main(string[] args)
        {
            int rtn = 0;
            int result = 0;
            try
            {
                // プロセスの起動
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/k dir");
                // プロセスを新しいウィンドウで起動する
                psi.CreateNoWindow = true;

                // プロセスの起動にシェルを使用する
                psi.UseShellExecute = true;

                // 下記3つはUseShellExecuteを使う場合はfalseにする必要がある
                // アプリケーションのエラー出力を StandardError ストリームに書き込むか
                psi.RedirectStandardError = false;
                // アプリケーションの入力を StandardInput ストリームから読み取るか
                psi.RedirectStandardInput = false;
                // アプリケーションのテキスト出力を StandardOutput ストリームに書き込むか
                psi.RedirectStandardOutput = false;

                // プロセスを起動するときに使用するウィンドウの状態を取得/設定
                // 最大化(Maximized)、最小化(Minimized)、通常(Normal) 、非表示(Hidden)が選べる
                psi.WindowStyle = ProcessWindowStyle.Normal;

                // 実行
                using (Process proc = Process.Start(psi))
                {
                    // 指定した時間が経過するかプロセスが終了するまで現在のスレッドの実行をブロックする
                    proc.WaitForExit();

                    // プロセスが終了時に指定された値を受け取る
                    result = proc.ExitCode;
                }
            }
            catch
            {
                rtn = -1;
            }

            Environment.ExitCode = rtn;
            return rtn;
        }
    }
}
