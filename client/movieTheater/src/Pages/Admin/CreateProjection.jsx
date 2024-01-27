import { useState, useEffect } from "react";
import { apiGet } from "../../utils/axios";

function CreateProjection() {
  const [data1, setData1] = useState(null);
  const [data2, setData2] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const url1 = "api/Movie";
        const url2 = "api/ProjectionHall";

        // Use Promise.all to wait for both requests to complete
        const [response1, response2] = await Promise.all([
          apiGet(url1),
          apiGet(url2),
        ]);
        console.log(response1);
        console.log(response2);
        // Extract the data from each response
        setData1(response1);
        setData2(response2);
      } catch (error) {
        console.error("Error fetching data:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  return (
    <div>
      asdsasdaadsdsaasdsdasadas
      {loading ? (
        <p>Loading...</p>
      ) : (
        <div>
          <h1>Data 1</h1>
          <pre>{JSON.stringify(data1, null, 2)}</pre>

          <h1>Data 2</h1>
          <pre>{JSON.stringify(data2, null, 2)}</pre>
        </div>
      )}
    </div>
  );
}

export default CreateProjection;
