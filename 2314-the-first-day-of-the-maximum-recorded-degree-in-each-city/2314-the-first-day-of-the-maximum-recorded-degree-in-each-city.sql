/* Write your T-SQL query statement below */

;WITH MaxDegreeCte (city_id,degree)
AS
(
    SELECT city_id, MAX(degree) AS degree
    FROM Weather
    GROUP BY city_id
)
    
SELECT w2.city_id, MIN(w2.day) AS day, w2.degree
FROM MaxDegreeCte w1 
JOIN Weather w2
ON w1.city_id = w2.city_id AND w1.degree = w2.degree
GROUP BY w2.city_id, w2.degree
ORDER BY w2.city_id