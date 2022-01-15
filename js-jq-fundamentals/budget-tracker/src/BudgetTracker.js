export default class BudgetTracker {
    constructor(querySelectorString) {
        this.root = document.querySelector(querySelectorString);
        //console.log(this.root);
        this.root.innerHTML = BudgetTracker.html();

        this.root.querySelector(".new-entry").addEventListener("click", () => {
            this.onNewEntryBtnClick();
        });

        //Load initial data from local Storage
        this.load();

    }

    static html() {
        return `
            <table class="budget-tracker">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Description</th>
                        <th>Type</th>
                        <th>Amount</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody class="entries">
                </tbody>
                <tbody>
                    <tr>
                        <td colspan="5" class="controls"><button type="button" class="new-entry">New Entry</button></td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="5" class="summary"><strong>Total: <span class="total">$0.00</span></strong></td>
                    </tr>
                </tfoot>
            </table>
        `

    }

    static entryHtml() {
        return `
            <tr>
                <td><input class="input input-date" type="date"></td>
                <td><input class="input input-description" type="text" placeholder="Description"></td>
                <td>
                    <select name="" class="input input-type">
                        <option value="income">Income</option>
                        <option value="expense">Expense</option>
                    </select>
                </td>
                <td><input class="input input-amount" type="number"></td>
                <td><button class="delete-entry" type="button">&#10005;</button></td>
            </tr>
        `
    }

    load() {
        const entries = JSON.parse(localStorage.getItem("budget-tracker-entries-dev") || "[]");

        // console.log(entries);
        for (const entry of entries) {
            this.addEntry(entry);
        }

        this.updateSummary();
    }

    updateSummary() {
        const total = this.getEntryRows().reduce((total, row) => {
            const amount = row.querySelector(".input-amount").value;
            const isExpense = row.querySelector(".input-type").value === "expense";

            const modifier = isExpense ? -1 : 1;

            return total + (amount * modifier);
        }, 0);
        const totalFormatted = new Intl.NumberFormat("en-US", {
            style: "currency",
            currency: "USD"
        }).format(total);

        this.root.querySelector(".total").textContent = totalFormatted;
    }

    save() {
        // console.log(this.getEntryRows());
        const data = this.getEntryRows().map(row => {
            return {
                date: row.querySelector(".input-date").value,
                description: row.querySelector(".input-description").value,
                type: row.querySelector(".input-type").value,
                amount:parseFloat(row.querySelector(".input-amount").value),
            };
        });
        // console.log(data);
        localStorage.setItem("budget-tracker-entries-dev", JSON.stringify(data));
        this.updateSummary();
    }

    addEntry(entry = {}) {
        this.root.querySelector(".entries").insertAdjacentHTML("beforeend", BudgetTracker.entryHtml());
        const row = this.root.querySelector(".entries tr:last-of-type");

        row.querySelector(".input-date").value = entry.date || new Date().toISOString().replace(/T.*/, "");
        row.querySelector(".input-description").value = entry.description || "";
        row.querySelector(".input-type").value = entry.type || "income";
        row.querySelector(".input-amount").value = entry.amount || 0;
        row.querySelector(".delete-entry").addEventListener("click", e => {
            this.onDeleteEntryBtnClick(e);
        })

        row.querySelectorAll(".input").forEach(input => {
            input.addEventListener("change", () => this.save());
        })

    }

    getEntryRows() {
        return Array.from(this.root.querySelectorAll(".entries tr"));
    }

    onNewEntryBtnClick() {
        this.addEntry();
    }

    onDeleteEntryBtnClick(e) {
        // console.log("I've been deleted");
        // console.log(e)
        e.target.closest("tr").remove();
        this.save();
    }
}