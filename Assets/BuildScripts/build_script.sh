#!/bin/bash

echo "[BUILDSCRIPT TESTE] Iniciando a build no ambiente configurado"
mkdir -p "output"
echo "[BUILDSCRIPT TESTE] Build concluída e armazenada em 'output'"

"C:/Program Files/Unity/Hub/Editor/2022.3.16f1/Editor/Unity.exe" -quit -batchMode -projectPath "C:/Users/thera/Projeto/JenkinsUnity" -executeMethod BuildScript.BuildWindowsDev

echo "[BUILDSCRIPT TESTE] Build process completed successfully"