using UnityEngine;
using System.Collections.Generic;
using System;

public class DSF : MonoBehaviour
{
    public GameObject[] nodes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Search(List<List<int>> adj, bool[] visited,int s, List<int> res)
    {
        visited[s] = true;
        res.Add(s);
        foreach (int i in adj[s])
        {
            if (!visited[i])
            {
                Search(adj, visited, i, res);
            }
        }

    }
    public List<int> DFS(List<List<int>> adj, int V, int S)
    {
        List<int> res = new List<int>();
        bool[] visited = new bool[V];
        Search(adj, visited, S, res);
        return res;
    }
    public void  theEdging(List<List<int>> adj, int V, int S)
    {
        adj[S].Add(V);
        adj[V].Add(S);
    }
    public void main ()
    {
        int V = 7;
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < V; i++)
        {
            adj.Add(new List<int>());
        }
        theEdging(adj, 0, 1);
        theEdging(adj, 0, 2);
        theEdging(adj, 1, 3);
        theEdging(adj, 1, 4);
        List<int> res = DFS(adj, V, 0);
        foreach (int i in res)
        {
            Debug.Log(i + " ");
        }
    }
}
