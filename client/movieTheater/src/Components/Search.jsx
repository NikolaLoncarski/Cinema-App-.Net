import React from "react";

function Search() {
  return (
    <form className="w-9/12 mb-36">
      <div class="flex">
        <label
          for="search-dropdown"
          class="mb-2 text-sm font-medium text-yellow-900 sr-only dark:text-white"
        >
          Your Email
        </label>
        <button
          id="dropdown-button"
          data-dropdown-toggle="dropdown"
          class="flex-shrink-0 z-10 inline-flex items-center py-2.5 px-4 text-sm font-medium text-center text-yellow-900 bg-yellow-100 border border-yellow-300 rounded-s-lg hover:bg-yellow-200 focus:ring-4 focus:outline-none focus:ring-yellow-100 dark:bg-yellow-700 dark:hover:bg-yellow-600 dark:focus:ring-yellow-700 dark:text-white dark:border-yellow-600"
          type="button"
        >
          All categories{" "}
        </button>
        <div
          id="dropdown"
          class="z-10 hidden bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700"
        >
          <ul
            class="py-2 text-sm text-gray-700 dark:text-gray-200"
            aria-labelledby="dropdown-button"
          >
            <li>
              <button
                type="button"
                class="inline-flex w-full px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
              >
                Mockups
              </button>
            </li>
            <li>
              <button
                type="button"
                class="inline-flex w-full px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
              >
                Templates
              </button>
            </li>
            <li>
              <button
                type="button"
                class="inline-flex w-full px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
              >
                Design
              </button>
            </li>
            <li>
              <button
                type="button"
                class="inline-flex w-full px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white"
              >
                Logos
              </button>
            </li>
          </ul>
        </div>
        <div class="relative w-full">
          <input
            type="search"
            id="search-dropdown"
            class="block p-2.5 w-full z-20 text-sm text-yellow-900 bg-yellow-50 rounded-e-lg border-s-yellow-50 border-s-2 border border-yellow-300 focus:ring-yellow-500 focus:border-yellow-500 dark:bg-yellow-700 dark:border-s-yellow-700  dark:border-yellow-600 dark:placeholder-yellow-400 dark:text-white dark:focus:border-yellow-500"
            placeholder="Search Mockups, Logos, Design Templates..."
            required
          />
          <button
            type="submit"
            class="absolute top-0 end-0 p-2.5 text-sm font-medium h-full text-white bg-yellow-700 rounded-e-lg border border-yellow-700 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yellow-300 dark:bg-yellow-600 dark:hover:bg-yellow-700 dark:focus:ring-yellow-800"
          >
            <span class="sr-only">Search</span>
          </button>
        </div>
      </div>
    </form>
  );
}

export default Search;
