echo "[BUILD SCRIPT TESTE] Iniciando a build no ambiente configurado"
mkdir -p "output"

"C:/Program Files/Unity/Hub/Editor/2022.3.16f1/Editor/Unity.exe" -quit -batchMode -projectPath "D:\Projetos\JenkinsUnity" -executeMethod BuildScript.BuildWindowsDev

echo "[Debug.BUILD SCRIPT] Build process completed successfully"