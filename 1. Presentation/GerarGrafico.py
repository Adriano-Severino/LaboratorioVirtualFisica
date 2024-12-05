import matplotlib.pyplot as plt
import pandas as pd
import os

def read_log_file(file_path):
    data = {
        'tempo': [],
        'posicao': [],
        'velocidade': [],
        'condicao': [],
        'forca': [],
        'massa': []
    }
    
    current_condition = ''
    current_force = 0
    current_mass = 0
    
    try:
        with open(file_path, 'r', encoding='utf-8') as file:
            for line in file:
                line = line.strip()
                if line.startswith('Com atrito') or line.startswith('Sem atrito'):
                    parts = line.split()
                    current_condition = f"{parts[0]} {parts[1]}"
                    current_force = int(parts[2].replace('N', ''))
                    current_mass = int(parts[3].replace('kg', ''))
                elif line and not line.startswith('--') and not line.startswith('Condição'):
                    try:
                        parts = line.split()
                        if len(parts) >= 3:
                            tempo = float(parts[0].replace('s', '').replace(',', '.'))
                            posicao = float(parts[1].replace('m', '').replace(',', '.'))
                            velocidade = float(parts[2].replace('m/s', '').replace(',', '.'))
                            
                            data['tempo'].append(tempo)
                            data['posicao'].append(posicao)
                            data['velocidade'].append(velocidade)
                            data['condicao'].append(current_condition)
                            data['forca'].append(current_force)
                            data['massa'].append(current_mass)
                    except (ValueError, IndexError):
                        continue
    except FileNotFoundError:
        print(f"Arquivo não encontrado: {file_path}")
        return None
    
    return pd.DataFrame(data)

def plot_graphs(df):
    if df is None or df.empty:
        print("Sem dados para plotar")
        return
        
    plt.style.use('default')
    fig, (ax1, ax2) = plt.subplots(2, 1, figsize=(12, 10))
    
    colors = ['#1f77b4', '#ff7f0e', '#2ca02c', '#d62728', '#9467bd']
    
    # Gráfico de Posição
    for idx, condition in enumerate(df['condicao'].unique()):
        mask = df['condicao'] == condition
        ax1.plot(df[mask]['tempo'], df[mask]['posicao'], 
                marker='o', 
                color=colors[idx % len(colors)],
                label=f"{condition} (F={df[mask]['forca'].iloc[0]}N, m={df[mask]['massa'].iloc[0]}kg)")
    
    ax1.set_title('Posição x Tempo', fontsize=14, pad=20)
    ax1.set_xlabel('Tempo (s)', fontsize=12)
    ax1.set_ylabel('Posição (m)', fontsize=12)
    ax1.grid(True, linestyle='--', alpha=0.7)
    ax1.legend(bbox_to_anchor=(1.05, 1), loc='upper left')
    
    # Gráfico de Velocidade
    for idx, condition in enumerate(df['condicao'].unique()):
        mask = df['condicao'] == condition
        ax2.plot(df[mask]['tempo'], df[mask]['velocidade'], 
                marker='o',
                color=colors[idx % len(colors)],
                label=f"{condition} (F={df[mask]['forca'].iloc[0]}N, m={df[mask]['massa'].iloc[0]}kg)")
    
    ax2.set_title('Velocidade x Tempo', fontsize=14, pad=20)
    ax2.set_xlabel('Tempo (s)', fontsize=12)
    ax2.set_ylabel('Velocidade (m/s)', fontsize=12)
    ax2.grid(True, linestyle='--', alpha=0.7)
    ax2.legend(bbox_to_anchor=(1.05, 1), loc='upper left')
    
    plt.tight_layout()
    plt.show()

# Caminho do arquivo
file_path = os.path.join('/log do registros laboratorio virtual de fisica.txt')
df = read_log_file(file_path)
plot_graphs(df)