class Solution {
public:
int fillCups(vector<int>& amount) {
priority_queue<int>pq;
for(int x:amount){
if(x>0)pq.push(x);
}
int ans=0;
while(pq.size()>1){
int a=pq.top();pq.pop();a--;
int b=pq.top();pq.pop();b--;
if(a>0)pq.push(a);
if(b>0)pq.push(b);
ans++;
}
if(pq.size())ans+=pq.top();
return ans;
}
};