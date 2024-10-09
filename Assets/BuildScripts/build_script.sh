#!/bin/bash

# Parâmetros do Jenkins
BUILD_NAME=$BUILD_NAME
BUILD_PATH=$BUILD_PATH

echo "[BUILDSCRIPT TESTE] Iniciando a build no ambiente configurado"
mkdir -p "$BUILD_PATH/$BUILD_NAME"
echo "[BUILDSCRIPT TESTE] Build concluída e armazenada em '$BUILD_PATH/$BUILD_NAME'"

# Executa o processo de build no Unity com os parâmetros
"C:/Program Files/Unity/Hub/Editor/2022.3.16f1/Editor/Unity.exe" -quit -batchMode -projectPath "C:/Users/thera/Projeto/JenkinsUnity" -executeMethod BuildScript.BuildWindowsDev -buildName $BUILD_NAME -buildPath $BUILD_PATH

echo "[BUILDSCRIPT TESTE] Build process completed successfully"
