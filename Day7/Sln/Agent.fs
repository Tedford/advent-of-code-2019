namespace Day7

type Agent<'T> = MailboxProcessor<'T>

type BatchProcessor<'T>(count) =
    let batchEvent = new Event<'T[]>()

    let reportBatch batch =
        try
            batchEvent.Trigger(batch)
        with e ->
            printfn "Handler failed %A" e

    let agent = Agent<'T>.Start(fun inbox -> async {
        while true do
            let queue = new ResizeArray<_>()
            for i in 1 .. count do
                let! msg = inbox.Receive()
                queue.Add(msg)
            reportBatch (queue.ToArray())
    })

    member this.BatchProduced = batchEvent.Publish
    member this.Post(value) = agent.Post(value)

