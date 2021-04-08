import os
import shutil

DLLS_PATH = os.getcwd() + '\\bin\\Debug\\net5.0\\'
DEBUG_DLLS_PATH = os.getcwd() + '\\obj\\Debug\\net5.0\\'
UNITY_DLLS_PLUGIN_PATH = os.getcwd().replace(r'Scripts\UnityCSV2SO\UnityToCSVSO\UnityToCSVSO', 'Plugins')

currentUnityPlugins = []

# print(UNITY_DLLS_PLUGIN_PATH)

for f in os.listdir(UNITY_DLLS_PLUGIN_PATH):
    currentUnityPlugins.append(f)

print(DLLS_PATH + 'ref')
for f in os.listdir(DLLS_PATH + 'ref'):
    print(f)
    if f in currentUnityPlugins:
        print('FOUND')
        os.remove(UNITY_DLLS_PLUGIN_PATH + '\\' + f)
        shutil.copyfile(DLLS_PATH + 'ref\\' + f, UNITY_DLLS_PLUGIN_PATH + '\\' + f)
    else:
        print('NOT FOUND ' + DLLS_PATH + 'ref\\' + f)
        shutil.copyfile(DLLS_PATH + 'ref\\' + f, UNITY_DLLS_PLUGIN_PATH + '\\' + f)

if os.path.exists(DLLS_PATH + 'ref\\UnityToCSVSO.dll'):
    os.remove(DLLS_PATH + 'ref\\UnityToCSVSO.dll')
if os.path.exists(DLLS_PATH + '\\UnityToCSVSO.dll'):
    os.remove(DLLS_PATH + '\\UnityToCSVSO.dll')
    
print(DEBUG_DLLS_PATH + 'ref\\UnityToCSVSO.dll')

if os.path.exists(DEBUG_DLLS_PATH + 'ref\\UnityToCSVSO.dll'):
    os.remove(DEBUG_DLLS_PATH + 'ref\\UnityToCSVSO.dll')
if os.path.exists(DEBUG_DLLS_PATH + '\\UnityToCSVSO.dll'):
    os.remove(DEBUG_DLLS_PATH + '\\UnityToCSVSO.dll')
