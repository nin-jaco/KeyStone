import scipy
from scipy import stats, optimize, interpolate
import numpy as np
import psycopg2
import pandas as pd

def doQuery(conn) :
    cur = conn.cursor()
    cur.execute("SELECT grand_parent_id, dwh_party_id FROM associations_sample_10k")
    return cur.fetchall()
    
    #for grand_parent_id, dwh_party_id in cur.fetchall() :
    #    print(grand_parent_id, dwh_party_id)

# Create a function that takes in x's and y's
def spearmans_rank_correlation(xs, ys):    
    # Calculate the rank of x's
    xranks = pd.Series(xs).rank(axis=0, method='max', numeric_only=False, ascending=False)    
    # Caclulate the ranking of the y's
    yranks = pd.Series(ys).rank(axis=0, method='max', numeric_only=False, ascending=False)    
    # Calculate Pearson's correlation coefficient on the ranked versions of the data
    return scipy.stats.spearmanr(xranks, yranks)
        
myConnection = psycopg2.connect(host="localhost", user="postgres", password="Leg@l123", dbname="KeyStone")
results = doQuery(myConnection)
myConnection.close()

x = results[0]
y = results[1]

print(spearmans_rank_correlation(x, y)[0])






