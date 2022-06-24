/* Write your T-SQL query statement below */

WITH CTE(city_id, day, degree, rank)
AS
(
    SELECT 
        city_id, 
        day,
        degree,
        RANK() OVER(PARTITION BY city_id ORDER BY degree desc, day asc) rank
    FROM 
        Weather
)
SELECT 
    city_id, 
    day, 
    degree
FROM CTE
WHERE 
    rank = 1
ORDER BY city_id